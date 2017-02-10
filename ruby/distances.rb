class Distances
    def initialize(root)
        @root = root
        @cells = {}
        @cells[@root] = 0
    end

    def [](cell)
        @cells[cell]
    end

    def []=(cell,distance)
        @cells[cell] = distance
    end

    def cells
        @cells.keys
    end

    def path_to(goal)
        current = goal

        breadcrumbs = Distances.new(@root)
        breadcrumbs[current] = @cells[current]

        until current == @root
            current.links.each do |linked_cell|
                if @cells[linked_cell] < @cells[current]
                    breadcrumbs[linked_cell] = @cells[linked_cell]
                    current = linked_cell
                    break
                end
            end
        end

        breadcrumbs
    end
end